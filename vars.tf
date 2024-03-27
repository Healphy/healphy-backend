variable "vpc_id" {
  type        = string
  description = ""
}

variable "public_subnets" {
  type        = list(string)
  default     = []
  description = "CIDRs for public subnets"
}