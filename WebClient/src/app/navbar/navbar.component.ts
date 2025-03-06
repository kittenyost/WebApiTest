import { Component } from '@angular/core';

export interface PostLink {
  slug: string;
  component: Component | undefined;
  path: string;
}

@Component({
  selector: 'app-nav',
  standalone: false,
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  staticPosts: PostLink[] = [
    {
      slug: 'taco-news',
      component: undefined,
      path: 'taco-news'
    },
    {
      slug: 'toast-news',
      component: undefined,
      path: 'toast-news'
    },
    {
      slug: 'hello',
      component: undefined,
      path: 'hello'
    },
    {
      slug: 'hello-world',
      component: undefined,
      path: 'hello-world'
    }
  ];
}
