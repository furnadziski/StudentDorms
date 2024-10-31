import { Component, EventEmitter, Input, OnInit, Output, ViewEncapsulation } from '@angular/core';
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  @Input() isExpanded: boolean;
  @Output() toggleMenu = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }
  accommodation
  public routeLinks = [
    { link: "dashboard", name: "menu_Dashboard", icon: "home", title: "Home" },
    { link: "accommodation", name: "menu_Accommodations",icon:"hotel icon", title: "Accommodations" },
    { link: "meals", name: "menu_Meals",icon:"fastfood icon", title: "Meals" },
    { link: "myprofile", name: "menu_Profile",icon:"home", title: "MyProfile" },
    { link: "payments", name: "menu_Payments",icon:"payment icon", title: "Payments" },
    { link: "tickets", name: "menu_Tickets",icon:"report problem icon", title: "Tickets" },
    { link: "configuration", name: "menu_Configuration",icon:"build icon", title: "Configuration" },
     { link: "food", name: "menu_Food", icon: "restaurant", title: "Food" }
  ];
}
