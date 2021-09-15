//<reference types="cypress" />

//const { data } = require("cypress/types/jquery")


describe('example scenario', () => {
    beforeEach(() => {
        // open the web app by accessing the localhost
        cy.visit('https://localhost:44351/')
    })

    it('displays user registration, login and purchase', () => {

        // REGISTER

        // click on the button 'Register' in the navigation bar in order to register
        cy.get('#register').click()

        // enter your email
        cy.get('#register-email').type("test@teeeeeeeeeeest.com")

        // enter your name
        cy.get('#register-name').type("Angela")

        // enter your surname
        cy.get('#register-surname').type("Madjar")

        // enter your address
        cy.get('#register-address').type("Address")

        // enter your password
        cy.get('#register-password').type("Test123!")

        // confirm your password
        cy.get('#register-confirmpassword').type("Test123!")

        // click on the 'Register' button
        cy.get('#register-btn').click()

        // confirm the registration
        cy.get('#confirm-link').click()



        // LOGIN

        // login
        cy.get('#login').click()

        // enter the email in order to log in
        cy.get('#login-email').type("test@teeeeeeeeeeest.com")

        // enter the password in order to log in
        cy.get('#login-password').type("Test123!")

        // click on the 'Log in' button
        cy.get('#login-btn').click()


        // NAVIGATE TO TICKETS

        // click the button 'Tickets' from the navigation bar
        cy.get('#tickets').click()


        // ADD TICKET TO SHOPPING CART

        // click the button 'Add to Cart' of the last ticket
        cy.get('#addtocart-btn').last().should('have.text', 'Add to Cart').click()

        // select the quantity of tickets to add in the shopping cart
        cy.get('#ticket-quantity').type(3)

        // add the tickets in the shopping cart
        cy.get('#ticket-quantity-save').click()



        // NAVIGATE TO SHOPPING CART

        // click the button 'Shopping Cart' from the navigation bar
        cy.get('#shoppingcart').click()

        // delete the last item in the shopping cart
        cy.get('#delete-from-shoppingcart').last().should('have.text', 'Delete').click()


        // NAVIGATE TO TICKETS

        // click the button 'Tickets' from the navigation bar
        cy.get('#tickets').click()


        // ADD ANOTHER TICKET IN THE SHOPPING CART

        // select another (the first) ticket in the shopping cart
        cy.get('#addtocart-btn').first().should('have.text', 'Add to Cart').click()

        // select the quantity of tickets to add in the shopping cart
        cy.get('#ticket-quantity').type(5)

        // add the tickets in the shopping cart
        cy.get('#ticket-quantity-save').click()


        // NAVIGATE TO SHOPPING CART

        // click the button 'Shopping Cart' from the navigation bar
        cy.get('#shoppingcart').click()


        // MAKE AN ORDER

        // order the items in the shopping cart
        cy.get('#order-now').click()
    })
})