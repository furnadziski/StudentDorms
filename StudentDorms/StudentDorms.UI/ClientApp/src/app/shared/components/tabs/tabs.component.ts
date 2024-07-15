import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { RouteLink } from '../../models/route-link.interface';
import { NavigationTab } from '../../models/shared/navigation-model';

@Component({
  selector: 'app-tab-loader',
  templateUrl: './tabs.component.html',
  styles: [
  ]
})
export class TabsComponent implements OnInit, OnChanges {

  @Input() tabs: RouteLink[] = [];
  @Output() startingTab: EventEmitter<NavigationTab> = new EventEmitter();

  routeLinks: RouteLink[] = [];


  navigationTab: NavigationTab;
  
  constructor() { }

  ngOnInit(): void {
    this.navigationTab = new NavigationTab();
    this.filterTabs();
  }

  ngOnChanges(changes: SimpleChanges){
    if(changes['currentValue'] != changes['previousValue']){
      this.routeLinks = this.tabs;
    }
  }

  setActiveTab(index: number): void {
    this.routeLinks.forEach((link, i) => {
      link.isActive = i === index;
    });
  }

  filterTabs(){
    this.tabs.forEach(element => {
        this.routeLinks.push(element);
    });
    
    if(this.routeLinks.length > 0){
      this.navigationTab.url = this.routeLinks[0].routerLink;
      this.startingTab.emit(this.navigationTab)
    }
    else{
      this.navigationTab.url = null;
      this.startingTab.emit(this.navigationTab);
    }
  }

}
