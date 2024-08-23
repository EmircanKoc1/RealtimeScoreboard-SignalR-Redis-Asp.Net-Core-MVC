﻿using RealtimeScoreBoard.WebApp.Repositories;

namespace RealtimeScoreBoard.WebApp.Services
{
    public class ScoreboardService : IScoreboardService
    {
        private readonly IRedisSortedSetRepository _repository;

        public const string SORTED_SET_KEY = "SeasonGoolScores";
        public ScoreboardService(IRedisSortedSetRepository repository)
        {
            _repository = repository;
        }

        public async Task DecreaseScoreAsync(string member, int score)
        {

            await _repository.DecreaseScore(SORTED_SET_KEY, member, score);

        }

        public async Task IncreaseScoreAsync(string member, int score)
        {
            await _repository.IncreaseScore(SORTED_SET_KEY, member, score);

        }

        public async Task UpdateScoreAsync(string member, int score)
        {
            await _repository.UpdateScore(SORTED_SET_KEY, member, score);

        }

        public async Task<IEnumerable<ValueTuple<string, string>>> GetScoreWithMembersAsync(string key)
        {
            var result =await _repository.GetScoresWithMembers(SORTED_SET_KEY);
            return result;
        }
    }

}