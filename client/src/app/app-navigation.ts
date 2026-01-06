import { Actions } from "./models/permission/actions";
import { Resources } from "./models/permission/resources"; 

export const navigation = [
  {
    text: 'Navs.Home',
    icon: 'home',
    path: '',
    items: [
      {
        text: 'Navs.Home',
        path: '/home',
        permission:  Resources.Dashboard + '.' + Actions.View
      } 
    ],
  },
  {
    text: 'Navs.Admin',
    icon: 'card',
    path: '',
    items: [
      {
        text: 'Navs.MainRoles',
        path: '/roles',
        permission: Resources.Roles + '.' + Actions.View
      },
      {
        text: 'Navs.Users',
        path: '/users',
        permission: Resources.Users + '.' + Actions.View
      },
       {
        text: 'Navs.Customers',
        path: '/customers',
        permission: Resources.Customers + '.' + Actions.View
      },
      {
        text: 'Navs.Brands',
        path: '/brands',
        permission: Resources.Brands + '.' + Actions.View
      }
    ],
  },
  {
    text: 'Navs.Payments',
    icon: 'money',
    path: '',
    items: [
      {
        text: 'Navs.PayEasy',
        path: '/payeasy',
        permission: Resources.Payments + '.' + Actions.PayEasy
      } 
    ],
  },
  // {
  //   text: 'Navs.Operations',
  //   icon: 'home',
  //   path: '',
    // items: [
    //   {
    //     text: 'Navs.PayEasy',
    //     path: '/payeasy',
    //     permission: Resources.Payments + '.' + Actions.PayEasy
    //   } 
    // ],
  //},
  // Diğer menü öğeleri...
];
