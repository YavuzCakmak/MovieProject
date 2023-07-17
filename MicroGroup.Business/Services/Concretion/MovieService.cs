using AutoMapper;
using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Business.Session;
using MicroGroup.Core.Business.Concretion;
using MicroGroup.Core.UnitOfWork.Abstraction;
using MicroGroup.Data.Context;
using MicroGroup.Data.Repository.Abstraction;
using MicroGroup.Model.Dto;
using MicroGroup.Model.Entity.Movie;
using MicroGroup.Model.Model.Movie;
using MicroGroup.Model.Utilities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroGroup.Business.Services.Concretion
{
    public class MovieService : BusinessService<MovieEntity, MovieModel, IMovieRepository, MicroGroupDbContext>, IMovieService
    {
        private readonly SessionManager _sessionManager;
        public MovieService(IUnitOfWork<MicroGroupDbContext, MovieEntity, IMovieRepository> uow, IMapper mapper, SessionManager sessionManager) : base(uow, mapper)
        {
            _sessionManager = sessionManager;
        }

        /// <summary>
        /// Film tavsiye etmek için kullanılan endPoint
        /// </summary>
        /// <param name="adviceMovieDto"></param>
        public void AdviceMovie(AdviceMovieDto adviceMovieDto)
        {
            var movieModel = base.GetList(x => x.Id == adviceMovieDto.MovieId).FirstOrDefault();
            if (movieModel != null)
            {
                string fromEmail = "movie_evaluation@hotmail.com";
                string toEmail = adviceMovieDto.ToEmail;

                string emailSubject = $"Film Tavsiyesi -- {movieModel.Name}";

                string emailBody = $"Merhaba, {_sessionManager.User.Username} kullanıcısı tarafından size bir film tavsiye edildi. Film Adı : {movieModel.Name} ";

                var message = new MimeKit.MimeMessage();
                message.From.Add(new MimeKit.MailboxAddress("Movie Advice", fromEmail));
                message.To.Add(MimeKit.MailboxAddress.Parse(toEmail));
                message.Subject = emailSubject;

                var builder = new MimeKit.BodyBuilder();
                builder.TextBody = emailBody;

                message.Body = builder.ToMessageBody();


                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.CheckCertificateRevocation = false;
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.office365.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(fromEmail, "evaluation123");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
        }
    }
}
