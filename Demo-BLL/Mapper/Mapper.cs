using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL = Demo_BLL.Entities;
using DAL = Demo_DAL.Entities;

namespace Demo_BLL
{
    static class Mapper
    {
        #region Mapper Client
        public static BLL.Client ToBLL(this DAL.Client entity)
        {
            if (entity is null) return null;
            return new BLL.Client()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }

        public static DAL.Client ToDAL(this BLL.Client entity)
        {
            if (entity is null) return null;
            return new DAL.Client()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }
        #endregion

        #region Mapper Spectacle
        public static BLL.Spectacle ToBLL(this DAL.Spectacle entity)
        {
            if (entity is null) return null;
            /* // AVEC Contructeur à 3 paramètres
             * return new BLL.Spectacle(
                entity.idSpectacle,
                entity.nom,
                entity.description
                );
            */
            //AVEC constructeur prévu pour la DAL
            return new BLL.Spectacle(entity);
        }

        public static DAL.Spectacle ToDAL(this BLL.Spectacle entity)
        {
            if (entity is null) return null;
            return new DAL.Spectacle()
            {
                idSpectacle = entity.idSpectacle,
                nom = entity.nom,
                description = entity.description
            };
        }
        #endregion

        #region Mapper Type
        public static BLL.Type ToBLL(this DAL.Type entity)
        {
            if (entity is null) return null;
            return new BLL.Type()
            {
                idType = entity.idType,
                nom = entity.nom,
                prix = entity.prix
            };
        }

        public static DAL.Type ToDAL(this BLL.Type entity)
        {
            if (entity is null) return null;
            return new DAL.Type()
            {
                idType = entity.idType,
                nom = entity.nom,
                prix = entity.prix
            };
        }
        #endregion

        #region Mapper Representation
        public static BLL.Representation ToBLL(this DAL.Representation entity)
        {
            if (entity is null) return null;
            return new BLL.Representation()
            {
                idRepresentation = entity.idRepresentation,
                dateheureRepresentation = entity.dateRepresentation.Add(entity.heureRepresentation),
                idSpectacle = entity.idSpectacle,
                spectacle = null
            };
        }

        public static DAL.Representation ToDAL(this BLL.Representation entity)
        {
            if (entity is null) return null;
            return new DAL.Representation()
            {
                idRepresentation = entity.idRepresentation,
                dateRepresentation = entity.dateheureRepresentation.Date,
                heureRepresentation = entity.dateheureRepresentation.TimeOfDay,
                idSpectacle = entity.spectacle?.idSpectacle ?? entity.idSpectacle
            };
        }
        #endregion
    }
}
