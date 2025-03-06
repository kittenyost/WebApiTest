import { Component } from "@angular/core";
import { DataService, Post } from "../data.service";


@Component({
  selector: 'app-post-list',
  standalone: false,
  templateUrl: './post-list.component.html',
  styleUrl: './post-list.component.css'
})
export class PostListComponent {
  posts: Post[] = [];

  constructor(private data: DataService) {
    this.data.getAllPosts().subscribe(data => {
      this.posts = data;
    });
  }

  onDelete(id: number) {
    console.log("I heard someone shouting at clouds");

    let deletedPost = this.posts.find(p => p.contentId == id);
    console.log("found post", deletedPost);

    if (deletedPost != undefined) {
      console.log("deletedPost should be defined");
      this.data.deletePost(deletedPost).subscribe(result => {
        console.log("post deleted", result);
        this.posts = this.posts.filter(p => p.contentId != id);
      });
    }
  }

  
}
