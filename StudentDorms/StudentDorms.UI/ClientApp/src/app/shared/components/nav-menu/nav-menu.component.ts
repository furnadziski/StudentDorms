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

  public routeLinks = [
    { link: "dashboard", name: "menu_Dashboard", icon: "home", title: "Почетна страна" },
     { link: "food", name: "menu_Food", icon: "restaurant", title: "Food" }
  ];
}
