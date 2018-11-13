using System.Linq;
using Raven.Client.Documents.Indexes;
using ravendb_getting_started.Models;

namespace ravendb_getting_started.Indexes
{
    public class Talks_SpeakerStats : AbstractIndexCreationTask<Talk, SpeakerTalkStats>
    {
        public Talks_SpeakerStats()
        {
            Map = talks =>
                from talk in talks
                select new
                {
                    Id = talk.Speaker,
                    SpeakerName = LoadDocument<Speaker>(talk.Speaker).Name,
                    Count = 1
                };

            Reduce = results =>
                from rr in results
                group rr by rr.SpeakerName into g
                select new
                {
                    SpeakerName = g.Key,
                    Id = g.First().Id,
                    Count = g.Sum(r => r.Count)
                };
        }
    }
}