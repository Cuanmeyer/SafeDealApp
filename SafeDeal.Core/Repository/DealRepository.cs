using SafeDeal.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeDeal.Core.Repository
{
    public class DealRepository
    {
        public List<Deal> GetAllDeals()
        {
            IEnumerable<Deal> deals =
                from dealGroup in dealGroups
                from deal in dealGroup.Deals

                select deal;
            return deals.ToList<Deal>();
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

        public Deal GetDealById(int dealId)
        {
            IEnumerable<Deal> deals =
                from dealGroup in dealGroups
                from deal in dealGroup.Deals
                where deal.DealId == dealId
                select deal;

            return deals.FirstOrDefault();
        }






        //Hard Coded Deal Groups

        private static List<DealGroup> dealGroups = new List<DealGroup>()
        {
            new DealGroup()
            {
                DealGroupId = 1, Title = "Meat lovers", ImagePath = "", Deals = new List<Deal>()
                {
                    new Deal()
                    {
                        DealId = 1,
                        Name = "Young Soul T-Shirt",
                        ShortDescription = "Ghost Smiley on back and sleeve",
                        Description = "Distressed on the arms, this t-shirt is casual choice for any day or night out with friends",
                        ImagePath = "hotdog1",
                        Available = true,
                        PrepTime= 10,
                        Ingredients = new List<string>(){"Regular bun", "Sausage", "Ketchup"},
                        Price = 8,
                        IsFavorite = true
                    },
                    new Deal()
                    {
                        DealId = 2,
                        Name = "Jesus Jacket",
                        ShortDescription = "The classy one",
                        Description = "Bacon ipsum dolor amet turducken ham t-bone shankle boudin kevin. Hamburger salami pork shoulder pork chop. Flank doner turducken venison rump swine sausage salami sirloin kielbasa pork belly tail cow. Pork chop bacon ground round cupim tongue, venison frankfurter bresaola tri-tip andouille sirloin turducken spare ribs biltong. Drumstick ham hock pork tail, capicola shank frankfurter beef ribs jowl meatball turkey hamburger. Tenderloin swine ham pork belly beef ribeye. ",
                        ImagePath = "hotdog2",
                        Available = true,
                        PrepTime= 15,
                        Ingredients = new List<string>(){"Baked bun", "Gourmet sausage", "Fancy mustard from Germany"},
                        Price = 10,
                        IsFavorite = false
                    },
                    new Deal()
                    {
                        DealId = 3,
                        Name = "Heaven's End",
                        ShortDescription = "For when a regular one isn't enough",
                        Description = "Capicola short loin shoulder strip steak ribeye pork loin flank cupim doner pastrami. Doner short loin frankfurter ball tip pork belly, shank jowl brisket. Kielbasa prosciutto chuck, turducken brisket short ribs tail pork shankle ball tip. Pancetta jerky andouille chuck salami pastrami bacon pig tri-tip meatball tail bresaola shank short ribs strip steak. Ham hock frankfurter ball tip, biltong cow pastrami swine tenderloin ground round pork loin t-bone. ",
                        ImagePath = "hotdog3",
                        Available = true,
                        PrepTime= 10,
                        Ingredients = new List<string>(){"Extra long bun", "Extra long sausage", "More ketchup"},
                        Price = 8,
                        IsFavorite = true
                    }
                }
            },
            new DealGroup()
            {
                DealGroupId = 2, Title = "Veggie lovers", ImagePath = "", Deals = new List<Deal>()
                {
                    new Deal()
                    {
                        DealId = 4,
                        Name = "Filling Pieces Sneaker",
                        ShortDescription = "Shipped straight from the U.S",
                        Description = "Veggies es bonus vobis, proinde vos postulo essum magis kohlrabi welsh onion daikon amaranth tatsoi tomatillo melon azuki bean garlic.\n\nGumbo beet greens corn soko endive gumbo gourd. Parsley shallot courgette tatsoi pea sprouts fava bean collard greens dandelion okra wakame tomato. Dandelion cucumber earthnut pea peanut soko zucchini.",
                        ImagePath = "hotdog4",
                        Available = true,
                        PrepTime= 10,
                        Ingredients = new List<string>(){"Bun", "Vegetarian sausage", "Ketchup"},
                        Price = 8,
                        IsFavorite = false
                    },
                    new Deal()
                    {
                        DealId = 5,
                        Name = "Veteran Cap",
                        ShortDescription = "Classy and veggie",
                        Description = "Turnip greens yarrow ricebean rutabaga endive cauliflower sea lettuce kohlrabi amaranth water spinach avocado daikon napa cabbage asparagus winter purslane kale. Celery potato scallion desert raisin horseradish spinach carrot soko. Lotus root water spinach fennel kombu maize bamboo shoot green bean swiss chard seakale pumpkin onion chickpea gram corn pea. Brussels sprout coriander water chestnut gourd swiss chard wakame kohlrabi beetroot carrot watercress. Corn amaranth salsify bunya nuts nori azuki bean chickweed potato bell pepper artichoke.",
                        ImagePath = "hotdog5",
                        Available = true,
                        PrepTime= 15,
                        Ingredients = new List<string>(){"Baked bun", "Gourmet vegetarian sausage", "Fancy mustard"},
                        Price = 10,
                        IsFavorite = true
                    },
                    new Deal()
                    {
                        DealId = 6,
                        Name = "Mandela Hoodie",
                        ShortDescription = "Mandela Didn't Die For This - Written on back",
                        Description = "Beetroot water spinach okra water chestnut ricebean pea catsear courgette summer purslane. Water spinach arugula pea tatsoi aubergine spring onion bush tomato kale radicchio turnip chicory salsify pea sprouts fava bean. Dandelion zucchini burdock yarrow chickpea dandelion sorrel courgette turnip greens tigernut soybean radish artichoke wattle seed endive groundnut broccoli arugula.",
                        ImagePath = "hotdog6",
                        Available = true,
                        PrepTime= 10,
                        Ingredients = new List<string>(){"Extra long bun", "Extra long vegetarian sausage", "More ketchup"},
                        Price = 8,
                        IsFavorite = false
                    }
                }
            }
        };

    }
}
