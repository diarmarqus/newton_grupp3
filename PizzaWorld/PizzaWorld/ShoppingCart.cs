﻿using System;
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
    public class ShoppingCart
    {
        public Menu menu = new Menu();

        public List<OrderDetails> orderDetails = new List<OrderDetails>();
        public OrderDetails workingOrderDetails;

        public void CreateOrder(pick_item pick, int place)
        {
            switch (pick)
            {
                case pick_item.pizza:
                    orderDetails.Add(new OrderDetails(menu.standardPizza[place]));
                    break;
                case pick_item.drinks:
                    menu.extraMenu.items.Add(Menu.drinks[place]);
                    break;
                case pick_item.sallad:
                    menu.extraMenu.items.Add(Menu.sallad[place]);
                    break;
                case pick_item.sauce:
                    menu.extraMenu.items.Add(Menu.sauce[place]);
                    break;
                default:
                    break;
            }    
        }

        public void DeleteOrder(pick_item pick, int place)
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

        public void ChangeQty(int place, int change)
        {
            orderDetails[place].qty += change;

        }

        public int CountTotalSum()
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
