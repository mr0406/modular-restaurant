using ModularRestaurant.Menus.Domain.Entities;
using ModularRestaurant.Menus.Domain.Repositories;
using ModularRestaurant.Shared.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModularRestaurant.Menus.Infrastructure.EF.Repositories
{
    internal class MenuRepository : IMenuRepository
    {
        public async Task AddAsync(Menu menu)
        {
            
        }

        public async Task<Menu> GetAsync()
        {
            var testMenu = new TestMenu
            {
                Groups = new List<TestGroup>
                {
                    new TestGroup
                    {
                        Name = "First",
                        Items = new List<TestItem>
                        {
                            new TestItem
                            {
                                Name = "1"
                            }
                        }
                    },
                    new TestGroup
                    {
                        Name = "Second",
                        Items = new List<TestItem>
                        {
                            new TestItem
                            {
                                Name = "12"
                            },
                            new TestItem
                            {
                                Name = "13"
                            }
                        }
                    },
                    new TestGroup
                    {
                        Name = "Third",
                        Items = new List<TestItem>
                        {
                            new TestItem
                            {
                                Name = "100"
                            },
                            new TestItem
                            {
                                Name = "101"
                            },
                            new TestItem
                            {
                                Name = "102"
                            },
                            new TestItem
                            {
                                Name = "103"
                            },
                        }
                    }
                }
            };

            var groups = testMenu.Groups.Select(x => Group.CreateNew(x.Name, x.Items
                                                        .Select(y => Item.CreateNew(y.Name)).ToList())).ToList();

            var restaurantId = new RestaurantId(Guid.NewGuid());

            var menu = Menu.CreateNew(restaurantId, groups);

            return await Task.FromResult(menu);
        }
    }

    public class TestMenu
    {
        public List<TestGroup> Groups { get; set; }
    }

    public class TestGroup
    {
        public string Name { get; set; }
        public List<TestItem> Items { get; set; }
    }

    public class TestItem
    {
        public string Name { get; set; }
    }
}
