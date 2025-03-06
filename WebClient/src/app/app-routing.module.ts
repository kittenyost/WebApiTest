import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { PostDetailComponent } from './post-detail/post-detail.component';
import { PostListComponent } from './post-list/post-list.component';
import { PostEditComponent } from './post-edit/post-edit.component';

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "post", component: PostListComponent },
  { path: "post/create", component: PostEditComponent },
  { path: "post/edit/:id", component: PostEditComponent },
  { path: "post/:id", component: PostDetailComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
