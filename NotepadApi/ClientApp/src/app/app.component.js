var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
import { Note } from './note';
let AppComponent = class AppComponent {
    constructor(dataService) {
        this.dataService = dataService;
        this.note = new Note();
        this.tableMode = true; // табличный режим
    }
    ngOnInit() {
        this.loadNotes();
    }
    // получаем данные через сервис
    loadNotes() {
        this.dataService.getNotes()
            .subscribe((data) => this.notes = data);
    }
    // сохранение данных
    save() {
        if (this.note.id == null) {
            this.dataService.createNote(this.note)
                .subscribe((data) => this.notes.push(data));
        }
        else {
            this.dataService.updateNote(this.note)
                .subscribe(data => this.loadNotes());
        }
        this.cancel();
    }
    editNote(n) {
        this.note = n;
    }
    cancel() {
        this.note = new Note();
        this.tableMode = true;
    }
    delete(n) {
        this.dataService.deleteNote(n.id)
            .subscribe(data => this.loadNotes());
    }
    add() {
        this.cancel();
        this.tableMode = false;
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        templateUrl: './app.component.html',
        providers: [DataService]
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map