using Demo_ASP.Models.ClientViewModels;
using Demo_ASP.Models.SpectacleViewModels;
using Demo_BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP.Handlers
{
    public static class Mapper
    {
        #region Mappers Client
        public static ClientListItem ToListItem(this Client entity)
        {
            if (entity is null) return null;
            return new ClientListItem()
            {
                idClient = entity.idClient,
                nom = entity.nom,
                prenom = entity.prenom
            };
        }

        public static Client ToBLL(this ClientCreateForm entity)
        {
            if (entity is null) return null;
            return new Client()
            {
                nom = entity.nom,
                prenom = entity.prenom,
                email = entity.email,
                pass = entity.pass,
                adresse = entity.adresse
            };
        }
        #endregion
        #region Mappers Spectacle
        public static SpectacleListItem ToListItem(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleListItem()
            {
                idSpectacle = entity.idSpectacle,
                nom = entity.nom,
                description = entity.description
            };
        }

        public static SpectacleDetails ToDetails(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleDetails()
            {
                idSpectacle = entity.idSpectacle,
                nom = entity.nom,
                description = entity.description,
                Representations = entity.representations.Select(e => e.dateheureRepresentation)
            };
        }

        public static SpectacleDelete ToDelete(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleDelete()
            {
                idSpectacle = entity.idSpectacle,
                nom = entity.nom
            };
        }
        public static SpectacleEditForm ToEdit(this Spectacle entity)
        {
            if (entity is null) return null;
            return new SpectacleEditForm()
            {
                nom = entity.nom,
                description = entity.description
            };
        }

        public static Spectacle ToBLL(this SpectacleCreateForm entity)
        {
            if (entity is null) return null;
            return new Spectacle(default(int),entity.nom, entity.description);
        }

        public static Spectacle ToBLL(this SpectacleEditForm entity)
        {
            if (entity is null) return null;
            return new Spectacle(default(int), entity.nom, entity.description);
        }
        #endregion
    }
}
