import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { EditPetComponent } from './components/edit-pet/edit-pet.component';
import { IndexComponent } from './components/index/index.component';
import { NewPetComponent } from './components/new-pet/new-pet.component';

const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'newpet', component: NewPetComponent },
  { path: 'editpet', component: EditPetComponent },
  { path: 'accommodations', component: AccommodationsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
