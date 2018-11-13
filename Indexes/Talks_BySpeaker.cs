using System.Linq;
using Raven.Client.Documents.Indexes;
using ravendb_getting_started.Models;

namespace ravendb_getting_started.Indexes
{
    public class Talks_BySpeaker : AbstractIndexCreationTask<Talk>
    {
        public Talks_BySpeaker()
        {
            Map = talks =>
                from talk in talks
                select new
                {
                    talk.Speaker
                };
        }
    }
}