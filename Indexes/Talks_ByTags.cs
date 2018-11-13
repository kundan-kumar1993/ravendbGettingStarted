using System.Linq;
using Raven.Client.Documents.Indexes;
using ravendb_getting_started.Models;

namespace ravendb_getting_started.Indexes
{
    public class Talks_ByTags : AbstractIndexCreationTask<Talk>
    {
        public Talks_ByTags()
        {
            Map = talks =>
                from talk in talks
                select new
                {
                    talk.Tags
                };
        }
    }
}