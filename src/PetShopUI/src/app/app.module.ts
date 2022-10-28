import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './components/index/index.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { EditPetComponent } from './components/edit-pet/edit-pet.component';
import { NewPetComponent } from './components/new-pet/new-pet.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';
import { SearchPetComponent } from './components/search-pet/search-pet.component';
import { ListPetComponent } from './components/list-pet/list-pet.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    FooterComponent,
    HeaderComponent,
    EditPetComponent,
    NewPetComponent,
    AccommodationsComponent,
    SearchPetComponent,
    ListPetComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
