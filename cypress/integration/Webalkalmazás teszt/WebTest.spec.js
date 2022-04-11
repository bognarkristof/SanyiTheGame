/// <reference types="cypress"/>
import "../../support/commands";
import "../../support/index";



describe('Sanyi Web Test', () =>{

    beforeEach('viewport', () =>{
        cy.viewport(1920,1080);
    })

    it('visit the page',()=>{
        cy.visit('https://sanyithegame.000webhostapp.com/');           //Sanyi weboldal megnyitása
    })

    it('Registration', () =>{
        cy.get('.drop_btn').click(); //account gomb
        cy.get('.menu-bar > :nth-child(3) > a').click(); //create account gomb
        cy.wait(2000);
        cy.get('.user-details > :nth-child(1) > input').type('a', {force: true}); //username
        cy.get('.user-details > :nth-child(2) > input').type('SzabolcsPeter', {force: true}); //full name
        cy.get(':nth-child(3) > input').type('26', {force:true}); //age
        cy.get(':nth-child(4) > input').type('sanyitheemail@gmail.com', {force:true}); //email
        cy.get(':nth-child(5) > input').type('sanyithegame', {force:true}); //kód1
        cy.get(':nth-child(6) > input').type('sanyithegame', {force:true}); //kód2
        cy.get('#privacy').click(); //privacypolicy
        
         //create account gomb
        cy.get('.pt-4 > :nth-child(1) > form > .button').click();
        
    })

    it('Login and edit and admin edit', () =>{
        
        cy.visit('https://sanyithegame.000webhostapp.com/');           //Sanyi weboldal megnyitása
        
        cy.get('.drop_btn').click({force:true});
        cy.get('.user-details-login > :nth-child(1) > input').type('a'); //login név
        cy.get('.user-details-login > :nth-child(2) > input').type('sanyithegame'); //login jelszó
        cy.get('.container > form > .button > input').click();

        cy.get(':nth-child(5) > i').click({force:true});

        cy.get('.emailChangerInput').clear({force:true}).type('sanyigame@gmail.com', {force:true}); //email változtatása
        cy.get('.emailChangerButton > input').click({force:true}) //új email mentése
        cy.get(':nth-child(6) > i').click({force:true});
        cy.get('.fullnameChangerInput').clear({force:true}).type('SzabiPeti', {force:true}); //név változtatása
        cy.get('.fullnameChangerButton > input').click({force:true}) //új név mentése
        cy.get(':nth-child(7) > i').click({force:true}); 
        cy.get('.ageChangerInput').clear({force:true}).type('66', {force:true}); //kor átírása
        cy.get('.ageChangerButton > input').click({force:true}); //age change

        cy.get(':nth-child(1) > input').type('sanyithegame'); //régi jelszó
        cy.get('.user-details > :nth-child(2) > input').type('sannyer123'); //új jelszó
        cy.get('.user-details > :nth-child(3) > input').type('sannyer123'); //új jelszó megerősítése
        cy.get('.title > form > .button > input').click({force:true}); //save button
        cy.wait(2000);
        cy.get('.drop_btn').click({force:true}); //account gomb

        cy.get('.login-Title > form > :nth-child(3) > input').click({force:true}); //logout

        cy.get('.drop_btn').click(); //account button
        cy.get(':nth-child(1) > input').type('qqqqq'); //felhasználónév
        cy.get('.user-details-login > :nth-child(2) > input').type('qqqqq321'); //jelszó
        cy.wait(2000);
        cy.get('.button > input').click();
        cy.get('.drop_btn').click();
        cy.get(':nth-child(4) > input').click({force:true});

        cy.get(':nth-child(1) > :nth-child(7) > .btn-info').click({force:true});
        cy.get(':nth-child(1) > input').clear({force:true}).type('666', {force:true});
        cy.get('.user-details > :nth-child(2) > input').clear({force:true}).type('aa', {force:true}); 
        cy.get('.user-details > :nth-child(3) > input').clear({force:true}).type('126', {force:true}); //coin: 126
        cy.get('.user-details > :nth-child(4) > input').clear({force:true}).type('127', {force:true}); //score: 127
        cy.get('.user-details > :nth-child(5) > input').clear({force:true}).type('128', {force:true}); //Sanyi: 128
        cy.get('.accountManage > form > .button > input').click({force:true});
        cy.get(':nth-child(1) > :nth-child(7) > .btn-primary').click({force:true}); //admin user
        cy.get('.btn-warning').click({force:true});
        cy.get(':nth-child(1) > :nth-child(7) > .btn-danger').click({force:true}); //delete user
    });



   





})