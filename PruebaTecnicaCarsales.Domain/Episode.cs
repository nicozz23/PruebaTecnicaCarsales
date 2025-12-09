using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaCarsales.Domain
{
    public class Episode
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public required string AirDate { get; init; }
        public required string Code { get; init; }
        public required List<string> CharacterUrls { get; init; }
        public required string Url { get; init; }
        public DateTime Created { get; init; }
    }
}
