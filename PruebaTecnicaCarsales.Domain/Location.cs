using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Domain
{
    public class Location
    {
        public required int Id { get; init; }
        public required string Name { get; init; }
        public required string Type { get; init; }
        public required string Dimension { get; init; }
        public required string Url { get; init; }
        public DateTime Created { get; init; }
        public required List<string> ResidentUrls { get; init; }

        /* 
         Type
        Dimension
        url
        created
        residents (lista de URLs de personajes que residen en esta ubicación)
         */
    }
}
