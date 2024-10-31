import { Component, OnInit } from '@angular/core';
import { ConfigurationService } from '../../services/configuration.service';
import { RouteLink } from 'src/app/shared/models/route-link.interface';
import { ActivatedRoute, Router } from '@angular/router';
@Component({
  selector: 'app-configuration-home',
  templateUrl: './configuration-home.component.html',
  styleUrls: ['./configuration-home.component.scss']
})
export class ConfigurationHomeComponent implements OnInit {

  routeLinks: RouteLink[] = [];
  routerLinkActive: string = "routerlinkActive";
  
  constructor(private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.loadTabs();
  }

  setActiveTab(index){
    this.routeLinks.forEach((link, i) => {
      link.isActive = i === index;
    });
  }

  loadTabs() {
    this.routeLinks.push({ routerLink: "users", routerLinkActive: "routerLinkActive", title: "Корисници", isActive: true, name: "tab_Users", order: 1 })
     this.routeLinks.push({ routerLink: "student-dorms", routerLinkActive: "routerLinkActive", title: "Студентски домови", isActive: true, name: "tab_Student_Dorms", order: 2 })
     this.routeLinks.push({ routerLink: "registers", routerLinkActive: "routerLinkActive", title: "Шифрарници", isActive: true, name: "tab_Registers", order: 3 })
   
  }
}
