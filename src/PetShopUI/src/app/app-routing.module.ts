import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { EditPetComponent } from './components/edit-pet/edit-pet.component';
import { IndexComponent } from './components/index/index.component';
import { NewPetComponent } from './components/new-pet/new-pet.component';
import { SearchPetComponent } from './components/search-pet/search-pet.component';
import { ListPetComponent } from './components/list-pet/list-pet.component';

const routes: Routes = [
  { path: '', component: IndexComponent },
  { path: 'newPet', component: NewPetComponent },
  { path: 'editPet', component: EditPetComponent },
  { path: 'accommodations', component: AccommodationsComponent },
  { path: 'searchPet', component: SearchPetComponent },
  { path: 'listPet', component: ListPetComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
