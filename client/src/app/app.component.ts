import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { filter, map } from 'rxjs';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ RouterModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
})
export class AppComponent {
  title = 'desk-booking-ui';
  currentRoute: string = '';

  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    this.router.events
      .pipe(
        filter((event) => event instanceof NavigationEnd),
        map(() => {
          let route = this.activatedRoute;
          while (route.firstChild) {
            route = route.firstChild;
          }
          return route;
        }),
        map((route) => route.snapshot.data['title'])
      )
      .subscribe((title) => {
        this.title = title || 'angular-app';
        this.currentRoute = this.router.url;
      });
  }

  isActiveRoute(baseRoute: string): boolean {
    return (
      this.currentRoute === baseRoute ||
      this.currentRoute.startsWith(baseRoute + '/') ||
      this.currentRoute.startsWith(baseRoute + '?')
    );
  }
}
