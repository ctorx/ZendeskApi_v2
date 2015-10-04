﻿using System.Collections.Generic;
#if ASYNC
using System.Threading.Tasks;
#endif
using ZendeskApi_v2.Models.Targets;

namespace ZendeskApi_v2.Requests
{
    public interface ITargets : ICore
    {
#if SYNC
        GroupTargetResponse GetAllTargets();
        IndividualTargetResponse GetTarget(long id);
        IndividualTargetResponse CreateTarget(BaseTarget target);
        IndividualTargetResponse UpdateTarget(BaseTarget target);
        bool DeleteTarget(long id);
#endif

#if ASYNC
        Task<GroupTargetResponse> GetAllTargetsAsync();
        Task<IndividualTargetResponse> GetTargetAsync(long id);
        Task<IndividualTargetResponse> CreateTargetAsync(BaseTarget target);
        Task<IndividualTargetResponse> UpdateTargetAsync(BaseTarget target);
        Task<bool> DeleteTargetAsync(long id);
#endif
    }
    public class Targets : Core, ITargets
    {
        public Targets(string yourZendeskUrl, string user, string password, string apiToken, string p_OAuthToken)
            : base(yourZendeskUrl, user, password, apiToken, p_OAuthToken)
        {
        }

#if SYNC
        public GroupTargetResponse GetAllTargets()
        {
            return GenericGet<GroupTargetResponse>("targets.json");
        }

        public IndividualTargetResponse GetTarget(long id)
        {
            return GenericGet<IndividualTargetResponse>(string.Format("targets/{0}.json", id));
        }

        public IndividualTargetResponse CreateTarget(BaseTarget target)
        {
            var body = new { target };
            return GenericPost<IndividualTargetResponse>("targets.json", body);
        }

        public IndividualTargetResponse UpdateTarget(BaseTarget target)
        {
            var body = new { target };
            return GenericPut<IndividualTargetResponse>(string.Format("targets/{0}.json", target.Id), body);
        }

        public bool DeleteTarget(long id)
        {
            return GenericDelete(string.Format("targets/{0}.json", id));
        }
#endif

#if ASYNC
        public async Task<GroupTargetResponse> GetAllTargetsAsync()
        {
            return await GenericGetAsync<GroupTargetResponse>("targets.json");
        }

        public async Task<IndividualTargetResponse> GetTargetAsync(long id)
        {
            return await GenericGetAsync<IndividualTargetResponse>(string.Format("targets/{0}.json", id));
        }

        public async Task<IndividualTargetResponse> CreateTargetAsync(BaseTarget target)
        {
            var body = new { target };
            return await GenericPostAsync<IndividualTargetResponse>("targets.json", body);
        }

        public async Task<IndividualTargetResponse> UpdateTargetAsync(BaseTarget target)
        {
            var body = new { target };
            return await GenericPutAsync<IndividualTargetResponse>(string.Format("targets/{0}.json", target.Id), body);
        }

        public async Task<bool> DeleteTargetAsync(long id)
        {
            return await GenericDeleteAsync(string.Format("targets/{0}.json", id));
        }
#endif
    }
}
