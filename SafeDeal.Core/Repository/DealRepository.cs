using Newtonsoft.Json;
using SafeDeal.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SafeDeal.Core.Repository
{
    public class DealRepository
    {

        string url = "C:\\Users\\cuan.meyer\\Documents\\hotdogs[1].json";
        private static List<DealGroup> dealGroups = new List<DealGroup>();

        public DealRepository()
        {
            Task.Run(() => this.LoadDataAsync(url)).Wait();
        }
     
       

        private async Task LoadDataAsync(string uri)
        {
            if (dealGroups != null)
            {
                string responseJsonString = null;

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        Task<HttpResponseMessage> getResponse = httpClient.GetAsync(uri);

                        HttpResponseMessage response = await getResponse;

                        responseJsonString = await response.Content.ReadAsStringAsync();
                        dealGroups = JsonConvert.DeserializeObject<List<DealGroup>>(responseJsonString);
                    }
                    catch (Exception ex)
                    {
                        //handle any errors here, not part of the sample app
                        string message = ex.Message;
                    }
                }
            }
        }

        public List<Deal> GetAllDeals()
        {
            IEnumerable<Deal> deals =
                from dealGroup in dealGroups
                from deal in dealGroup.Deals

                select deal;
            return deals.ToList<Deal>();
        }
      

        public Deal GetDealById(int dealId)
        {
            IEnumerable<Deal> deals =
                from dealGroup in dealGroups
                from deal in dealGroup.Deals
                where deal.DealId == dealId
                select deal;

            return deals.FirstOrDefault();
        }

        public List<DealGroup> GetGroupedDeals()
        {
            return dealGroups;
        }

        public List<Deal> GetDealsForGroup(int dealGroupId)
        {
            var group = dealGroups.Where(h => h.DealGroupId == dealGroupId).FirstOrDefault();

            if (group != null)
            {
                return group.Deals;
            }
            return null;
        }



        public List<Deal> GetFavoriteDeals()
        {
            IEnumerable<Deal> deals =
                from dealGroup in dealGroups
                from deal in dealGroup.Deals
                where deal.IsFavorite
                select deal;

            return deals.ToList<Deal>();
        }






    }
}
