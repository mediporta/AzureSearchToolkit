using Microsoft.Azure.Search.Models;
using System.Collections.Generic;

namespace AzureSearchToolkit
{
    public class IndexScoringProfiles
    {
        public IList<ScoringProfile> Profiles { get; set; }

        public string DefaultProfile { get; set; }
    }
}
