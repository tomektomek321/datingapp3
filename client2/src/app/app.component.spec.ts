import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {

    let component: AppComponent;
    let fixture: ComponentFixture<AppComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
        imports: [
            RouterTestingModule
        ],
        declarations: [
            AppComponent
        ],
        providers: [

        ]
        }).compileComponents();

        fixture = TestBed.createComponent(AppComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();

    });


    it('should create the app', () => {
        expect(component).toBeTruthy();
    });

    it('should render title', () => {
        const selector = fixture.nativeElement as HTMLElement;
        expect(selector.querySelector('h1')?.textContent).toContain('Hello');
    });

    it('should render title 2', () => {
        const selector = fixture.nativeElement as HTMLElement;
        expect(selector.querySelector('h1')?.innerHTML).toBe('Hello');
    });

    it('x variable to be "Hello"', () => {
        const value = component.x;
        expect(value).toEqual('Hello');
    });

    it('should X variable change value to Hello2', (done) => {
        component.x = "Hello2";
        fixture.detectChanges();
        fixture.whenStable().then(res => {
            const newValue = fixture.debugElement.nativeElement.querySelector('h1').textContent;
            expect(newValue).toEqual("Hello2");
            done();
        });
    });




    // element.getAttrivute("placeholder")
    // element.dataset.widget
    // element['data'widget'] .. // ???

});
