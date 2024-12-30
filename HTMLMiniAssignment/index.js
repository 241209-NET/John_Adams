// Show an alert message when the first button is clicked
function showAlert() {
    alert("Button clicked! It was an alert!");
}

// Change the background color of the page when the second button is clicked
function changeBackground() {
    // Generate random RGB values
    const r = Math.floor(Math.random() * 256); // Red
    const g = Math.floor(Math.random() * 256); // Green
    const b = Math.floor(Math.random() * 256); // Blue

    // Combine into an RGB string
    const randomColor = `rgb(${r}, ${g}, ${b})`;

    // Apply the random color to the background
    document.body.style.backgroundColor = randomColor;
}

// Display a picture at the bottom of the page when the third button is clicked
function showPicture() {
    const pictures = [
        "https://www.akc.org/wp-content/uploads/2017/11/Shiba-Inu-standing-in-profile-outdoors.jpg", // Example picture 1
        "https://s3.amazonaws.com/cdn-origin-etr.akc.org/wp-content/uploads/2017/11/06154034/Akita-standing-outdoors-in-the-summer.jpg", // Example picture 2
        "https://cataas.com/cat", // Example picture 3
        "https://www.akc.org/wp-content/uploads/2017/11/French-Bulldog-laying-down-in-the-grass.jpg"     // Example picture 4
    ];

    // Pick a random picture
    const randomPicture = pictures[Math.floor(Math.random() * pictures.length)];

    // Create an image element
    const img = document.createElement("img");
    img.src = randomPicture;
    img.alt = "Random Picture";
    img.style.display = "block";
    img.style.margin = "20px auto"; // Centers the image horizontally

    // Append the image to the body
    document.body.appendChild(img);
}
