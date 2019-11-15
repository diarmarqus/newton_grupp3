using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaWorld
{
    public enum pick_item
    {
        pizza = 0,
        drinks = 1,
        sallad = 2,
        sauce = 3
    }

    /// <summary>
    /// Class for all the the orders the user has stored
    /// </summary>
    public static class ShoppingCart
    {
        public static Menu menu = new Menu();


        // Variables that stores all the orders the users has picked
        public static List<OrderDetails> orderDetails = new List<OrderDetails>();
        public static OrderDetails drinksOrderDetails = new OrderDetails(new ExtraMenu(new List<string>(), "Drinks", 20));
        public static OrderDetails salladOrderDetails = new OrderDetails(new ExtraMenu(new List<string>(), "Sallad", 20));
        public static OrderDetails sauceOrderDetails = new OrderDetails(new ExtraMenu(new List<string>(), "Sauce", 20));
        public static OrderDetails workingOrderDetails;


        /// <summary>
        /// stores an order
        /// </summary>
        /// <param name="pick">Category</param>
        /// <param name="place">Position of the menu item</param>
        public static void CreateOrder(pick_item pick, int place)
        {
            switch (pick)
            {
                case pick_item.pizza:
                    orderDetails.Add(new OrderDetails(menu.standardPizza[place]));
                    break;
                case pick_item.drinks:
                    drinksOrderDetails.orderItem.items.Add(Menu.drinks[place]);
                    break;
                case pick_item.sallad:
                    salladOrderDetails.orderItem.items.Add(Menu.sallad[place]);
                    break;
                case pick_item.sauce:
                    sauceOrderDetails.orderItem.items.Add(Menu.sauce[place]);
                    break;
                default:
                    break;
            }    
        }


        /// <summary>
        /// stores an order 
        /// but with changed ingredients
        /// changedIngredients contains all the positions that are changed
        /// </summary>
        /// <param name="pick">Category</param>
        /// <param name="place">Position of the menu item</param>
        /// <param name="changedIngredients">An array of all the positions in the items list</param>
        public static void CreateOrder(pick_item pick, int place, bool[] changedIngredients)
        {
            switch (pick)
            {
                case pick_item.pizza:
                    OrderDetails oPizza = new OrderDetails(menu.standardPizza[place]);
                    oPizza.orderItem.items = new List<string>();
                    for (int i = 0; i < Menu.ingredients.Count; i++)
                    {
          
                        if (changedIngredients[i] == true) {
                            oPizza.orderItem.items.Add(Menu.ingredients[i]);
                        }
                    }
                    orderDetails.Add(oPizza);
                    break;
                case pick_item.drinks:
                    for (int i = 0; i < Menu.drinks.Count; i++)
                    {
                        if (changedIngredients[i] == true)
                        {
                            drinksOrderDetails.orderItem.items.Add(Menu.drinks[i]);
                        }
                    }
                    break;
                case pick_item.sallad:
                    for (int i = 0; i < Menu.sallad.Count; i++)
                    {
                        if (changedIngredients[i] == true)
                        {
                            salladOrderDetails.orderItem.items.Add(Menu.sallad[i]);
                        }
                    }
                    break;
                case pick_item.sauce:
                    for (int i = 0; i < Menu.sauce.Count; i++)
                    {
                        if (changedIngredients[i] == true)
                        {
                            sauceOrderDetails.orderItem.items.Add(Menu.sauce[i]);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public static void DeleteOrder(pick_item pick, int place)
        {
            switch (pick)
            {
                case pick_item.pizza:
                    orderDetails.RemoveAt(place);
                    break;
                case pick_item.drinks:
                    menu.extraMenu.items.RemoveAt(place);
                    break;
                case pick_item.sallad:
                    menu.extraMenu.items.RemoveAt(place);
                    break;
                case pick_item.sauce:
                    menu.extraMenu.items.RemoveAt(place);
                    break;
                default:
                    break;
            }

        }

        public static void ChangeQty(int place, int change)
        {
            orderDetails[place].qty += change;

        }

        public static int CountTotalSum()
        {
            int sum = 0;
            for (int i = 0; i < orderDetails.Count; i++)
            {
                sum = sum + orderDetails[i].price;
            }
            sum += menu.extraMenu.totalPrice;
            return sum;
        }

  
    }
}
