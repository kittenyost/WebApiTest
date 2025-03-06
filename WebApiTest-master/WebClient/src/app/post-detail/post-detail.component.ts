import { Component, OnInit } from '@angular/core';
import { DataService, Post } from '../data.service';
import { ActivatedRoute, Router } from '@angular/router';
import { mergeMap, tap } from 'rxjs/operators';

@Component({
  selector: 'app-post-detail',
  standalone: false,
  templateUrl: './post-detail.component.html',
  styleUrl: './post-detail.component.css'
})
export class PostDetailComponent implements OnInit {
  id: number = 0;
  post: Post | undefined;

  isLoaded: boolean = false;

  constructor(private data: DataService,
    private route: ActivatedRoute,
    private router: Router) {

    this.id = 0;
    this.post = {
      contentId: 0,
      title: "",
      body: "",
      createdAt: new Date(),
      updatedAt: new Date(),
      categoryId: 0,
      category: {
          categoryId: 0,
          categoryName: '',
          postedContent: []
      },
      visibility: 0
    };

  }

  ngOnInit(): void {
    this.route.paramMap.pipe(
      mergeMap(params => {
        this.id = Number(params.get("id"));
        return this.data.getPostById(this.id)
      })
    ).subscribe(data => {
      console.log(data);
      this.post = data;
      this.isLoaded = true;
    });
  }

}
