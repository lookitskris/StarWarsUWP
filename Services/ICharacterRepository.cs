using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWars.Services
{
    public interface ICharacterRepository
    {
        Task<List<Character>> GetCharacters();
    }
}
