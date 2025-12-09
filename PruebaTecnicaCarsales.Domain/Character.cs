using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Domain
{
    public class Character
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string Status { get; init; } // ej. Alive, Dead, unknown
        public required string Species { get; init; }
        public required string Gender { get; init; }
        public required string ImageUrl { get; init; } // La URL de la imagen del personaje
        public required string OriginName { get; init; }
        public required string LocationName { get; init; }
        public required List<string> EpisodeUrls { get; init; }
        //public required DateTime Created { get; init; }
        public required string Created { get; init; }

    }
}
