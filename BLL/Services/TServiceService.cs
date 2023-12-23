using Interfaces.Services;
using DomainModel;
using Interfaces.DTO;
using System.Collections.Generic;
using System.Linq;
using Repository;
using Services;

namespace BLL.Services
{
    public class TServiceService : ITServiceService//бизнес-логика над данными (ф-ция и crud)
    {
        private IDbRepos db;
        public TServiceService(IDbRepos repos)
        {
            db = repos;
        }

        public List<Type_of_serviceDTO> GetAllTServices()
        {
            return db.TServices.GetList().Select(i => new Type_of_serviceDTO(i)).ToList();
        }


        public Type_of_serviceDTO GetTService(int Id)
        {
            return new Type_of_serviceDTO(db.TServices.GetItem(Id));
        }

        public void CreateTService(Type_of_serviceDTO p)
        {//id y мото
            db.TServices.Create(new Type_of_service()
            {
                description_of_service = p.description_of_service,
                cost_of_m2 = p.cost_of_m2,
                cost_of_m = p.cost_of_m
            });
            Save();
        }

        public void UpdateTService(Type_of_serviceDTO p)
        {
            Type_of_service ph = db.TServices.GetItem(p.Id);
            ph.description_of_service = p.description_of_service;
            ph.cost_of_m2 = p.cost_of_m2;
            ph.cost_of_m = p.cost_of_m;
            db.TServices.Update(ph);
            Save();
        }

        public void DeleteTService(int id)
        {
            Type_of_service p = db.TServices.GetItem(id);
            if (p != null)
            {
                db.TServices.Delete(p.Id);
                Save();
            }
        }


        public bool Save()
        {
            if (db.Save() > 0) return true;
            return false;
        }
    }
}
