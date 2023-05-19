import os
from PIL import Image
from fpdf import FPDF
pdf = FPDF()
# Directory containing images
dir_path = "/"
for file_name in os.listdir(dir_path):
    if file_name.endswith(".jpg") or file_name.endswith(".png"):
        image_path = os.path.join(dir_path, file_name)
        image = Image.open(image_path)
        pdf.add_page()
        pdf.image(image_path, 0, 0)
pdf.output("binder.pdf", "F")
