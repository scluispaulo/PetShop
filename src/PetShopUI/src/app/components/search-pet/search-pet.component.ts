import { Component, OnInit,EventEmitter, Input } from '@angular/core';
import { Pet } from 'src/app/interfaces/Pet';
import { Router } from '@angular/router';
import { PetService } from '../../services/pet.service';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-search-pet',
  templateUrl: './search-pet.component.html',
  styleUrls: ['./search-pet.component.css']
})
export class SearchPetComponent implements OnInit {
  petList: Pet[] = [];
  showResult: boolean = false;
  isPetSelected: boolean = false;

  searchForm = this.fb.group({
    petName: ['', Validators.compose([Validators.required, Validators.minLength(3)])]
  });

  constructor(
    private petService: PetService,
    private router: Router,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.petService.selectedPet.subscribe(pet => this.isPetSelected = pet.id !== 0)
  }

  searchPet(): void {
    this.petService.searchPet(this.searchForm.value.petName).subscribe(
      (data: Pet[]) => {
        this.petList = data;
        this.showResult = true;},
      error => {
        alert(`Error: ${error.statusText}`);
        this.router.navigate(['/']);}
    );
  }
}
