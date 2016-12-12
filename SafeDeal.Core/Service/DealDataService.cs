using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SafeDeal.Core;
using SafeDeal.Core.Repository;
using SafeDeal.Core.Model;

namespace SafeDeal.Core.Service
{
   public class DealDataService
    {
        public static DealRepository dealRepository = new DealRepository();

        public List<Deal> GetAllDeals()
        {
            return dealRepository.GetAllDeals();
        }

        public List<DealGroup> GetGroupedDeals()
        {
            return dealRepository.GetGroupedDeals();
        }

        public List<Deal> GetDealsForGroup(int dealGroupId)
        {
            return dealRepository.GetDealsForGroup(dealGroupId);
        }

        public List<Deal> GetFavoriteDeals()
        {
            return dealRepository.GetFavoriteDeals();
        }

        public Deal GetDealById(int dealId)
        {
            return dealRepository.GetDealById(dealId);
        }
    }
}
