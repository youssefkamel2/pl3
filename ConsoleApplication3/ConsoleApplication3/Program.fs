open System
open System.Collections.Generic
open System.Drawing
open System.Windows.Forms

// Define the products map
let products = 
    [
        "Product1", ("Laptop", 1200.0, "A powerful laptop for professionals.", "C:\\images\\sss.jpg")
        "Product2", ("Smartphone", 800.0, "A sleek smartphone with a high-resolution display.", "C:\\images\\sss.jpg")
        "Product3", ("Desk Chair", 150.0, "Ergonomic desk chair with lumbar support.", "C:\\images\\sss.jpg")
        "Product4", ("Backpack", 50.0, "Spacious backpack for travel and work.", "C:\\images\\sss.jpg")
        "Product5", ("Bluetooth Headphones", 200.0, "Noise-canceling headphones with crystal-clear sound.", "C:\\images\\sss.jpg")
        "Product6", ("Coffee Maker", 100.0, "Automatic coffee maker with a timer.", "C:\\images\\sss.jpg")
        "Product7", ("Running Shoes", 70.0, "Lightweight running shoes with good traction.", "C:\\images\\sss.jpg")
        "Product8", ("Notebook", 5.0, "Compact notebook for taking notes.", "C:\\images\\sss.jpg")
        "Product9", ("Electric Kettle", 30.0, "Fast boiling electric kettle with auto shut-off.", "C:\\images\\sss.jpg")
        "Product10", ("Wireless Mouse", 25.0, "Smooth and precise wireless mouse.", "C:\\images\\sss.jpg")
        "Product11", ("Tablet", 300.0, "Portable tablet with a 10-inch screen.", "C:\\images\\sss.jpg")
        "Product12", ("Gaming Keyboard", 80.0, "Mechanical keyboard with RGB lighting.", "C:\\images\\sss.jpg")
        "Product13", ("Fitness Tracker", 50.0, "Track your daily activity and workouts.", "C:\\images\\sss.jpg")
        "Product14", ("Smartwatch", 150.0, "Stylish smartwatch with fitness tracking features.", "C:\\images\\sss.jpg")
        "Product15", ("Camera", 500.0, "High-resolution camera for capturing memories.", "C:\\images\\sss.jpg")
        "Product16", ("Electric Toothbrush", 40.0, "Advanced toothbrush for better oral hygiene.", "C:\\images\\sss.jpg")
        "Product17", ("Portable Speaker", 60.0, "Compact speaker with great sound quality.", "C:\\images\\sss.jpg")
        "Product18", ("External Hard Drive", 120.0, "Reliable external storage for your files.", "C:\\images\\sss.jpg")
        "Product19", ("Monitor", 250.0, "27-inch monitor with 4K resolution.", "C:\\images\\sss.jpg")
        "Product20", ("Desk Lamp", 20.0, "Adjustable desk lamp with LED lighting.", "C:\\images\\sss.jpg")
        "Product21", ("Wireless Charger", 40.0, "Charge your devices without any cables.", "C:\\images\\sss.jpg")
        "Product22", ("Action Camera", 300.0, "Capture stunning videos in action-packed moments.", "C:\\images\\sss.jpg")
        "Product23", ("USB Flash Drive", 15.0, "Convenient storage for your documents.", "C:\\images\\sss.jpg")
        "Product24", ("Standing Desk", 350.0, "Adjustable height desk for better posture.", "C:\\images\\sss.jpg")
        "Product25", ("Water Bottle", 20.0, "Stainless steel water bottle with thermal insulation.", "C:\\images\\sss.jpg")
        "Product26", ("Smart Thermostat", 120.0, "Control your home's temperature from anywhere.", "C:\\images\\sss.jpg")
        "Product27", ("Robot Vacuum", 300.0, "Automatic vacuum cleaner for effortless cleaning.", "C:\\images\\sss.jpg")
        "Product28", ("Digital Picture Frame", 80.0, "Display your memories in a dynamic way.", "C:\\images\\sss.jpg")
        "Product29", ("Smart Lock", 200.0, "Secure your home with keyless entry.", "C:\\images\\sss.jpg")
        "Product30", ("Air Fryer", 150.0, "Cook healthier meals with less oil.", "C:\\images\\sss.jpg")
        "Product31", ("Gaming Headset", 90.0, "Immersive sound for your gaming experience.", "C:\\images\\sss.jpg")
        "Product32", ("Blender", 60.0, "High-speed blender for smoothies and shakes.", "C:\\images\\sss.jpg")
        "Product33", ("Yoga Mat", 25.0, "Non-slip mat for yoga and exercise.", "C:\\images\\sss.jpg")
        "Product34", ("Camping Tent", 120.0, "Spacious tent for outdoor adventures.", "C:\\images\\sss.jpg")
        "Product35", ("Electric Scooter", 400.0, "Eco-friendly personal transportation.", "C:\\images\\sss.jpg")
        "Product36", ("Microwave Oven", 100.0, "Compact microwave with multiple settings.", "C:\\images\\sss.jpg")
        "Product37", ("Smart Doorbell", 150.0, "See who's at your door from your phone.", "C:\\images\\sss.jpg")
        "Product38", ("Electric Grill", 200.0, "Grill indoors with no smoke.", "C:\\images\\sss.jpg")
        "Product39", ("Kids Tablet", 100.0, "Durable tablet designed for children.", "C:\\images\\sss.jpg")
        "Product40", ("Vacuum Cleaner", 150.0, "Powerful vacuum for deep cleaning.", "C:\\images\\sss.jpg")
        "Product41", ("Drone", 500.0, "Fly and capture stunning aerial photos.", "C:\\images\\sss.jpg")
        "Product42", ("Electric Bike", 1000.0, "Eco-friendly electric-powered bike.", "C:\\images\\sss.jpg")
        "Product43", ("Hair Dryer", 50.0, "Quick-drying hair dryer with adjustable settings.", "C:\\images\\sss.jpg")
        "Product44", ("Smart Light Bulbs", 70.0, "Color-changing LED bulbs with smart controls.", "C:\\images\\sss.jpg")
        "Product45", ("Kitchen Scale", 30.0, "Accurate digital scale for cooking.", "C:\\images\\sss.jpg")
        "Product46", ("Luggage Set", 200.0, "Durable and lightweight luggage for travel.", "C:\\images\\sss.jpg")
        "Product47", ("Electric Blanket", 60.0, "Stay warm with this cozy electric blanket.", "C:\\images\\sss.jpg")
        "Product48", ("Fitness Bench", 150.0, "Adjustable bench for home workouts.", "C:\\images\\sss.jpg")
        "Product49", ("Smart Plug", 30.0, "Control appliances remotely.", "C:\\images\\sss.jpg")
        "Product50", ("Wireless Earbuds", 100.0, "True wireless earbuds with excellent sound quality.", "C:\\images\\sss.jpg")
    ] |> Map.ofList

// Create a cart panel for the cart page
let cartPanel = new FlowLayoutPanel()

// Function to create a product card
let createProductCard (name: string, price: float, description: string, imagePath: string) =
    let card = new Panel()
    card.Size <- Size(400, 180)
    card.BorderStyle <- BorderStyle.FixedSingle
    card.Margin <- Padding(10)

    let pictureBox = new PictureBox()
    pictureBox.Size <- Size(100, 100)
    pictureBox.Location <- Point(10, 25)
    pictureBox.BorderStyle <- BorderStyle.Fixed3D
    try
        pictureBox.Image <- Image.FromFile(imagePath)
        pictureBox.SizeMode <- PictureBoxSizeMode.StretchImage
    with
    | :? System.IO.FileNotFoundException ->
        pictureBox.Image <- null

    let nameLabel = new Label()
    nameLabel.Text <- name
    nameLabel.Font <- new Font("Arial", 12.0f, FontStyle.Bold)
    nameLabel.Location <- Point(120, 10)
    nameLabel.AutoSize <- true

    let priceLabel = new Label()
    priceLabel.Text <- sprintf "Price: $%.2f" price
    priceLabel.Location <- Point(120, 40)
    priceLabel.AutoSize <- true

    let descLabel = new Label()
    descLabel.Text <- description
    descLabel.Location <- Point(120, 70)
    descLabel.Size <- Size(260, 50)
    descLabel.AutoEllipsis <- true

    let addToCartButton = new Button()
    addToCartButton.Text <- "Add to Cart"
    addToCartButton.Size <- Size(100, 30)
    addToCartButton.Location <- Point(120, 130)

    card.Controls.Add(pictureBox)
    card.Controls.Add(nameLabel)
    card.Controls.Add(priceLabel)
    card.Controls.Add(descLabel)

    card

[<EntryPoint>]
let main _ =

    let flowPanel = new FlowLayoutPanel()
    flowPanel.Dock <- DockStyle.Fill
    flowPanel.AutoScroll <- true

    products
    |> Map.iter (fun _ (name, price, description, imagePath) ->
        let card = createProductCard(name, price, description, imagePath)
        flowPanel.Controls.Add(card))

    form.Controls.Add(flowPanel)

    Application.Run(form)
    0
