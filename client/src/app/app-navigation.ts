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
  // =====================================================
  // VEM - Veri Entegrasyon Merkezi
  // =====================================================
  {
    text: 'VEM Hasta',
    icon: 'user',
    path: '',
    items: [
      { text: 'Hastalar', path: '/vem/hasta' },
      { text: 'Hasta Basvuru', path: '/vem/hasta-basvuru' },
      { text: 'Hasta Hizmet', path: '/vem/hasta-hizmet' },
      { text: 'Hasta Yatak', path: '/vem/hasta-yatak' },
      { text: 'Anlik Yatan Hasta', path: '/vem/anlik-yatan-hasta' },
    ],
  },
  {
    text: 'VEM Ameliyat',
    icon: 'medkit',
    path: '',
    items: [
      { text: 'Ameliyat', path: '/vem/ameliyat' },
      { text: 'Ameliyat Ekip', path: '/vem/ameliyat-ekip' },
      { text: 'Ameliyat Islem', path: '/vem/ameliyat-islem' },
      { text: 'Konsultasyon', path: '/vem/konsultasyon' },
    ],
  },
  {
    text: 'VEM Laboratuvar',
    icon: 'flask',
    path: '',
    items: [
      { text: 'Tetkik', path: '/vem/tetkik' },
      { text: 'Tetkik Sonuc', path: '/vem/tetkik-sonuc' },
      { text: 'Radyoloji', path: '/vem/radyoloji' },
      { text: 'Patoloji', path: '/vem/patoloji' },
    ],
  },
  {
    text: 'VEM Stok',
    icon: 'product',
    path: '',
    items: [
      { text: 'Stok Kart', path: '/vem/stok-kart' },
      { text: 'Stok Durum', path: '/vem/stok-durum' },
      { text: 'Stok Hareket', path: '/vem/stok-hareket' },
      { text: 'Depo', path: '/vem/depo' },
    ],
  },
  {
    text: 'VEM Personel',
    icon: 'group',
    path: '',
    items: [
      { text: 'Personel', path: '/vem/personel' },
      { text: 'Personel Izin', path: '/vem/personel-izin' },
      { text: 'Personel Bordro', path: '/vem/personel-bordro' },
    ],
  },
  {
    text: 'VEM Tanimlar',
    icon: 'folder',
    path: '',
    items: [
      { text: 'Kurum', path: '/vem/kurum' },
      { text: 'Birim', path: '/vem/birim' },
      { text: 'Bina', path: '/vem/bina' },
      { text: 'Oda', path: '/vem/oda' },
      { text: 'Yatak', path: '/vem/yatak' },
      { text: 'Hizmet', path: '/vem/hizmet' },
      { text: 'Referans Kodlar', path: '/vem/referans-kodlar' },
    ],
  },
];
