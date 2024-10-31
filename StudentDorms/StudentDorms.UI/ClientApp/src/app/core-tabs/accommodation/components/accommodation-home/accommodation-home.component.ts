import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RouteLink } from 'src/app/shared/models/route-link.interface';
import { UtilsService } from 'src/app/shared/services/utils-service';

@Component({
  selector: 'app-accommodation-home',
  templateUrl: './accommodation-home.component.html',
  styleUrls: ['./accommodation-home.component.scss']
})
export class AccommodationHomeComponent implements OnInit {

  routeLinks: RouteLink[] = [];
  routerLinkActive: string = "routerlinkActive";

  constructor(
    private _utilsService: UtilsService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.loadTabs();
  }

  navigateTo($event: any) {
    this.router.navigate([$event.url], { relativeTo: this.route });
  }

  loadTabs() {
    this.routeLinks.push({ routerLink: "accommodation", routerLinkActive: "routerLinkActive", title: "Сместување", isActive: true, name: "tab_Accommodation", order: 1 })
   
  }
}
