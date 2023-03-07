using Demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL
{
    static class Mapper
    {
        public static Client ToClient(this IDataRecord record)
        {
            if (record is null) return null;
            return new Client()
            {
                idClient = (int)record[nameof(Client.idClient)],
                nom = (string)record[nameof(Client.nom)],
                prenom = (string)record[nameof(Client.prenom)],
                email = (string)record[nameof(Client.email)],
                pass = "********",
                adresse = (record[nameof(Client.adresse)] is DBNull) ? null : (string)record[nameof(Client.adresse)]
            };
        }

        public static Spectacle ToSpectacle(this IDataRecord record)
        {
            if (record is null) return null;
            return new Spectacle()
            {
                idSpectacle = (int)record[nameof(Spectacle.idSpectacle)],
                nom = (string)record[nameof(Spectacle.nom)],
                description = (string)record[nameof(Spectacle.description)]
            };
        }

        public static Entities.Type ToType(this IDataRecord record)
        {
            if (record is null) return null;
            return new Entities.Type()
            {
                idType = (int)record[nameof(Entities.Type.idType)],
                nom = (string)record[nameof(Entities.Type.nom)],
                prix = (decimal)record[nameof(Entities.Type.prix)]
            };
        }

        public static Entities.Representation ToRepresentation(this IDataRecord record)
        {
            if (record is null) return null;
            return new Entities.Representation()
            {
                idRepresentation = (int)record[nameof(Representation.idRepresentation)],
                dateRepresentation = (DateTime)record[nameof(Representation.dateRepresentation)],
                heureRepresentation = (TimeSpan)record[nameof(Representation.heureRepresentation)],
                idSpectacle = (int)record[nameof(Representation.idSpectacle)]
            };
        }
    }
}
