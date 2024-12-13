using SportsApp.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsApp.Repository
{
    public class TeamsRepository
    {
        private readonly string _connectionString;
        private readonly TeamsRepositorySettings _repoSettings;
        private ConcurrentDictionary<string, SportsTeam[]> _mockDb = new ConcurrentDictionary<string, SportsTeam[]>();

        public TeamsRepository(TeamsRepositorySettings repoSettings) {
            _repoSettings = repoSettings;
            _connectionString = _repoSettings.ConnectionString;

            initMockData();
        }

        private void initMockData()
        {
            _mockDb["Seattle"] = new SportsTeam[]
                                    { new SportsTeam("Seattle", "Seahawks"),
                                      new SportsTeam("Seattle", "Mariners"),
                                      new SportsTeam("Seattle", "Kraken") };

            _mockDb["Chicago"] = new SportsTeam[]
                                    { new SportsTeam("Chicago", "Bears"),
                                      new SportsTeam("Chicago", "Cubs") };
        }

        public bool Create()
        {
            return true;
        }

        public List<SportsTeam> Read(string city)
        {
            if (String.IsNullOrWhiteSpace(city))
            {
                List<SportsTeam> allTeams = new List<SportsTeam>();
                foreach (string mockCity in _mockDb.Keys)
                {
                    allTeams.AddRange(_mockDb[mockCity]);
                }

                return allTeams;
            }
            else if (!_mockDb.ContainsKey(city))
            {
                return new List<SportsTeam>();
            }

            return new List<SportsTeam>(_mockDb[city]);
        }

        public bool Update()
        {
            return true;
        }

        public bool Delete()
        {
            return true;
        }
    }
}
