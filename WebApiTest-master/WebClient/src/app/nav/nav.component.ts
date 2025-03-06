import { Component } from '@angular/core';

interface PageLink {
  id: number;
  component: Component | undefined;
  displayName: string;
}

@Component({
  selector: 'app-nav',
  standalone: false,
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {
  staticPages: PageLink[] = [
    {
        id: 1,
        component: undefined,
        displayName: 'Taco News'
    },
    {
        id: 2,
        component: undefined,
        displayName: 'Toast News'
    },
    {
        id: 3,
        component: undefined,
        displayName: 'Hello'
    },
    {
        id: 4,
        component: undefined,
        displayName: 'Hello World'
    }
  ];
}
