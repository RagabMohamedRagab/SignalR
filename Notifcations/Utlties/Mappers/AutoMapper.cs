using AutoMapper;
using Notifcations.Models.Entities;
using Notifcations.ViewModels;

namespace Notifcations.Utlties.Mappers {
    public class AutoMapper: Profile {
        public AutoMapper()
        {
            CreateMap<Message, MessageViewModel>().ReverseMap();
        }
    }
}
