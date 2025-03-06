import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Post } from '../data.service';

// this is a dumb component

@Component({
  selector: 'app-post-item',
  standalone: false,
  templateUrl: './post-item.component.html',
  styleUrl: './post-item.component.css'
})
export class PostItemComponent {

  @Input() post!: Post;
  @Output() deletePost = new EventEmitter<number>();

  constructor() { }

  onDelete() {
    console.log("Shout at clouds");
    this.deletePost.emit(this.post.contentId);
  }
}
