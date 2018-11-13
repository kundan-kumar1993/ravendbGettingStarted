using System.Linq;
using Raven.Client.Documents.Indexes;
using ravendb_getting_started.Models;

namespace ravendb_getting_started.Indexes
{
    public class Talks_Search : AbstractIndexCreationTask<Talk>
    {
        public Talks_Search()
        {
            Map = talks => from talk in talks
                           select new
                           {
                               talk.Headline,
                               talk.Description
                           };

            Index(t => t.Headline, FieldIndexing.Search);
            Index(t => t.Description, FieldIndexing.Search);
        }
    }
}