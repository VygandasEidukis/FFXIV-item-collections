using FFXIVCollectors.Application.Common.Models.Entity;
using MediatR;

namespace FFXIVCollectors.Application.ControllerHandlers.Profiles.Commands
{
    public class CreateProfileCommand : IRequest<Profile>
    {
        public string Name { get; }
        public IEnumerable<int> Minions { get; }
        public IEnumerable<int> Mounts { get; }

        public CreateProfileCommand(string name, IEnumerable<int> minions, IEnumerable<int> mounts)
        {
            Name = name;
            Minions = minions ?? new List<int>();
            Mounts = mounts ?? new List<int>();
        }
    }
}
