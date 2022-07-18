import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
    beforeEach(async () => {
        await TestBed.configureTestingModule({
        imports: [
            RouterTestingModule
        ],
        declarations: [
            AppComponent
        ],
        }).compileComponents();
    });

    it('should create the app', () => {
        const fixture = TestBed.createComponent(AppComponent);
        const app = fixture.componentInstance;
        expect(app).toBeTruthy();
    });

    it('should render title', () => {
        const fixture = TestBed.createComponent(AppComponent);
        fixture.detectChanges();
        const selector = fixture.nativeElement as HTMLElement;
        expect(selector.querySelector('h1')?.textContent).toContain('App is working');
    });

    it('should render title 2', () => {
        const fixture = TestBed.createComponent(AppComponent);
        fixture.detectChanges();
        const selector = fixture.nativeElement as HTMLElement;
        expect(selector.querySelector('h1')?.innerHTML).toBe('App is working');
    });

    it('should X variable to be "Hej"', () => {
        const fixture = TestBed.createComponent(AppComponent);
        const instance = fixture.componentInstance;
        fixture.detectChanges();
        const value = instance.x;
        expect(value).toBe('hej');
    });

});
