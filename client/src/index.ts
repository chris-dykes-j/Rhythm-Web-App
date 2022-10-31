const uri: string = "https://localhost:7108"; // Update later.
let timeSignature: number, subDivision: number, totalNotes: number;

// Validates input, and fetches api.
document.getElementById("rhythm-build")!.addEventListener("submit", e => {
  e.preventDefault();
  getInput();
  if (validateInput())
    getRhythm();
  else
    displayError();
});

// Input method.
function getInput(): void {
  document.getElementsByName("time-sig").forEach(option => {
    if ((<HTMLInputElement>option).checked)
      timeSignature = parseInt((<HTMLInputElement>option).value);
  });
  document.getElementsByName("sub-div").forEach(option => {
    if ((<HTMLInputElement>option).checked)
      subDivision = parseInt((<HTMLInputElement>option).value);
  });
  totalNotes = parseInt((<HTMLInputElement>document.getElementById("notes")).value);
}

// Validation method
function validateInput(): boolean {
  if (timeSignature === undefined || subDivision === undefined || isNaN(totalNotes)) // Inputs are not empty.
    return false;  
  if (totalNotes >= timeSignature * subDivision || totalNotes === 0) // Is within range. 
    return false;
  return true;
}

// If valid, fetch with api url
async function getRhythm() {
  let img = <HTMLImageElement>document.getElementById("result");
  fetch(`${uri}/${timeSignature}/${subDivision}/${totalNotes}`)
    .then(response => response.json())
    .then(response => {
      console.log(response.value);
      img.src = response.value;
    })
    .catch(error => console.log(error));
}

// Should be a popup later
function displayError(): void {
  console.log("No!");
}