import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './components/index/index.component';
import { FooterComponent } from './components/footer/footer.component';
import { HeaderComponent } from './components/header/header.component';
import { EditPetComponent } from './components/edit-pet/edit-pet.component';
import { NewPetComponent } from './components/new-pet/new-pet.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AccommodationsComponent } from './components/accommodations/accommodations.component';

@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    FooterComponent,
    HeaderComponent,
    EditPetComponent,
    NewPetComponent,
    AccommodationsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
