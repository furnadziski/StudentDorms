import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RouteLink } from 'src/app/shared/models/route-link.interface';
import { UtilsService } from 'src/app/shared/services/utils-service';

@Component({
  selector: 'app-food-home',
  templateUrl: './food-home.component.html',
  styleUrls: ['./food-home.component.scss']
})
export class FoodHomeComponent implements OnInit {

  routeLinks: RouteLink[] = [];
  routerLinkActive: string = "routerlinkActive";

  constructor(
    private _utilsService: UtilsService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {

    this.routeLinks.push({ routerLink: "restaurants", routerLinkActive: "routerLinkActive", title: "Ресторани", isActive: true, name: "tab_Restaurants", order: 1 })
  }

  navigateTo($event: any) {
    this.router.navigate([$event.url], { relativeTo: this.route });
  }
}
