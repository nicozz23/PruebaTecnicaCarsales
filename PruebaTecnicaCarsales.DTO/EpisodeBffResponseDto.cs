using PruebaTecnicaCarsales.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.DTO
{
    public record EpisodeBffResponseDto
    {
        
        public int CurrentPage { get; init; }
        public int TotalPages { get; init; }
        public int TotalCount { get; init; }
        public bool HasNextPage { get; init; }
        public bool HasPrevPage { get; init; }

        public required List<Episode> Episodes { get; init; }
    }
}
